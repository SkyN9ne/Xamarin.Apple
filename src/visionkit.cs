//
// VisionKit C# bindings
//
// Authors:
//	Alex Soto  <alexsoto@microsoft.com>
//
// Copyright 2019 Microsoft Corporation. All rights reserved.
//

using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace VisionKit {

	[NoWatch, NoTV, NoMac, iOS (13, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface VNDocumentCameraScan {

		[Export ("pageCount")]
		nuint PageCount { get; }

		[Export ("imageOfPageAtIndex:")]
		UIImage GetImage (nuint pageIndex);

		[Export ("title", ArgumentSemantic.Strong)]
		string Title { get; }
	}

	[NoWatch, NoTV, NoMac, iOS (13, 0)]
	[BaseType (typeof (UIViewController))]
	interface VNDocumentCameraViewController {

		// Usual inlined ctors for UIViewController are marked as NS_UNAVAILABLE

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		IVNDocumentCameraViewControllerDelegate Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Static]
		[Export ("supported")]
		bool Supported { [Bind ("isSupported")] get; }
	}

	interface IVNDocumentCameraViewControllerDelegate { }

	[NoWatch, NoTV, NoMac, iOS (13, 0)]
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	[BaseType (typeof (NSObject))]
	interface VNDocumentCameraViewControllerDelegate {

		[Export ("documentCameraViewController:didFinishWithScan:")]
		void DidFinish (VNDocumentCameraViewController controller, VNDocumentCameraScan scan);

		[Export ("documentCameraViewControllerDidCancel:")]
		void DidCancel (VNDocumentCameraViewController controller);

		[Export ("documentCameraViewController:didFailWithError:")]
		void DidFail (VNDocumentCameraViewController controller, NSError error);
	}
}
